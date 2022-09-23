<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="NewAccountCreation.aspx.vb" Inherits="TransferSec_NewAccountCreation" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxEditors" Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxGridView" Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxLoadingPanel" Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<%--    <asp:scriptmanager runat="server"></asp:scriptmanager>--%>
    <asp:panel id="Panel1" runat="server" groupingtext="Account to be Captured" font-names="Cambria">
<%--        <asp:ScriptManager runat="server"></asp:ScriptManager>--%>
<%--<asp:UpdatePanel runat="server">--%>              

<%--            <div style="width: 100%; overflow: auto;">--%>
                <asp:GridView ID="grdApps" runat="server" AllowPaging="True" AutoGenerateColumns="True"
                                HorizontalAlign="Left" CssClass="table table-bordered table-striped tablestyle success"
                                EmptyDataText="0 records found!" EmptyDataRowStyle-CssClass="text-warning text-center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="header info" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:CommandField ItemStyle-Width="12.5%" SelectText="Select" ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
<%--                </div>--%>
             </asp:panel>

    <asp:panel id="panelCorp" runat="server" font-names="Cambria" groupingtext="Company Details" visible="False">
            <table style="width: 1004px">
                <tr>
                    <td colspan="1" style="width: 268px">
                        <dx:ASPxLabel ID="ASPxLabel77" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDS Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtSurname0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px">
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
                        <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px">
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
                        <dx:ASPxTextBox ID="txtOthernames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px">
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
                        <dx:ASPxTextBox ID="txtMiddleName" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px">
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
                        <dx:ASPxDateEdit ID="txtDOB" runat="server" EditFormat="Custom" EditFormatString="dd/MMMM/yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
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
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 158px;">
                    Joint Account Name<span style="color: red">*</span></td>

             
        
  

<%--               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">--%>
<%--                <asp:Label runat="server" Text="Forenames"></asp:Label><span style="color: red">*</span>--%>
<%--               </td>--%>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 395px;">
                   <asp:TextBox runat="server" ID="joAccName" Width="240px"></asp:TextBox>
               </td>
<%--               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">--%>
<%--                   <asp:Label runat="server" Text="Surname"></asp:Label><span style="color: red">*</span>--%>
<%--               </td>--%>
<%--               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">--%>
<%--                   <asp:TextBox runat="server"  ID="TextBox3"></asp:TextBox>--%>
<%--               </td>--%>
                       <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 246px;">CDS Number</td>
                       <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 447px;">
                           <asp:TextBox ID="cdsNumbers" runat="server" Width="240px"></asp:TextBox>
                       </td>
           </tr>
        

        </table>
     </asp:panel>


    <asp:panel id="personalDetails" runat="server" groupingtext="Personal Details" font-names="Cambria">
     <table style="width: 100%">
                   <tr>
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 143px;">
                    <asp:Label runat="server" Text="ID Number"></asp:Label>
                    <span style="color: red">*</span></td>

<%--               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">--%>
<%--                <asp:Label runat="server" Text="Forenames"></asp:Label><span style="color: red">*</span>--%>
<%--               </td>--%>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:TextBox runat="server" ID="idNumtext" ReadOnly="True"></asp:TextBox>
               </td>
<%--               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">--%>
<%--                   <asp:Label runat="server" Text="Surname"></asp:Label><span style="color: red">*</span>--%>
<%--               </td>--%>
<%--               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">--%>
<%--                   <asp:TextBox runat="server"  ID="TextBox3"></asp:TextBox>--%>
<%--               </td>--%>
           </tr>
        

          <tr>
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 143px;">
                    <asp:Label runat="server" Text="Title"></asp:Label>
                    <span style="color: red">*</span></td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   
                   
                                       <asp:DropDownList runat="server" ID="titleText" Width="151px">
                                              <asp:ListItem Text="--Select Title--" Value="0" />

                                                    <asp:ListItem Text="Mr." Value="Mr." />
                                                    <asp:ListItem Text="Mrs." Value="Mrs." />
                                                    <asp:ListItem Text="Miss." Value="Miss." />
                                                    <asp:ListItem Text="Ms." Value="Ms." />
                                                    <asp:ListItem Text="Sir." Value="Sir." />
                                                    <asp:ListItem Text="Esq." Value="Esq." />
                                                    <asp:ListItem Text="Rev." Value="Rev." />
                                                    <asp:ListItem Text="Dr." Value="Dr." />
                                                    <asp:ListItem Text="Prof." Value="Prof." />
                                                  
                                       </asp:DropDownList>
        
               </td>

               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">
                <asp:Label runat="server" Text="Forenames"></asp:Label><span style="color: red">*</span>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:TextBox runat="server" ID="forenamesText"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Surname"></asp:Label><span style="color: red">*</span>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server"  ID="surnameText"></asp:TextBox>
               </td>
           </tr>
        
         <tr>
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 143px;">
                    <asp:Label runat="server" Text="CDS Number"></asp:Label><span style="color: red">*</span>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                    <asp:TextBox runat="server"  ID="cdsNumberText" ReadOnly="True"></asp:TextBox>
               </td>

               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">
                <asp:Label runat="server" Text="Date of Birth"></asp:Label><span style="color: red">*</span>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                <BDP:BasicDatePicker ID="dateOfBirth" runat="server" ReadOnly="True">
                        </BDP:BasicDatePicker>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Gender"></asp:Label><span style="color: red">*</span>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                 <asp:RadioButtonList ID="rbtLstRating" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList> 
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
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 145px;">
                <asp:Label runat="server" Text="Address"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 100%;">
                   <asp:TextBox runat="server" ID="addressText" style="margin-left: 61px" Width="517px"></asp:TextBox>
               </td>
           </tr>
        </table>
        <table style="width: 100%">
            
            

          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 88px;">
                <asp:Label runat="server" Text="Country"></asp:Label><span style="color: red">*</span>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
<%--                   <asp:TextBox runat="server" ID="countryText"></asp:TextBox>--%>
                   
                       <asp:DropDownList runat="server" ID="countryText" style="width: 140px;">

                                                  
                                       </asp:DropDownList>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">
                   <asp:Label runat="server" Text="Phone"></asp:Label><span style="color: red">*</span>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:TextBox runat="server"  ID="phoneText" style="margin-left: 0px"></asp:TextBox>
               </td>
              
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 9px;">
                   <asp:Label runat="server" Text="Email"></asp:Label><span style="color: red">*</span>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                    <asp:TextBox runat="server"  ID="emailText"></asp:TextBox>
               </td>
           </tr>
        </table>
    </asp:panel>


    <asp:panel id="Panel3" runat="server" groupingtext="Trading Instructions" font-names="Cambria">
        <table style="width: 100%">
          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 75px;">
                <asp:Label runat="server" Text="Shares"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 97px; ">
                   <asp:TextBox runat="server" ID="custodyText" ReadOnly="True" style="margin-left: 0px"></asp:TextBox>
               </td>
             
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Select Custodian"></asp:Label><span style="color: red">*</span>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:DropDownList runat="server" ID="custodianSelect" Width="153px"></asp:DropDownList>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">&nbsp;</td>
           </tr>
        </table>
         <asp:GridView runat="server" ID="GridView1" ShowFooter="true" Width="100%">
             <HeaderStyle  HorizontalAlign="Left" />

         </asp:GridView>
    </asp:panel>

    <%----%>
    <%--    <asp:panel id="Panel5" runat="server" groupingtext="Industry Details" font-names="Cambria">--%>
    <%--        <table style="width: 100%">--%>
    <%--          <tr>--%>
    <%--               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">--%>
    <%--                <asp:Label runat="server" Text="Industry"></asp:Label>--%>
    <%--               </td>--%>
    <%--               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">--%>
    <%--                   <asp:TextBox runat="server" ID="industryText"></asp:TextBox>--%>
    <%--               </td>--%>
    <%--               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">--%>
    <%--                   <asp:Label runat="server" Text="Tax"></asp:Label>--%>
    <%--               </td>--%>
    <%--               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">--%>
    <%--                   <asp:TextBox runat="server"  ID="taxText"></asp:TextBox>--%>
    <%--               </td>--%>
    <%--           </tr>--%>
    <%--        </table>--%>
    <%--    </asp:panel>--%>


    <asp:panel id="Panel6" runat="server" groupingtext="Banking Details" font-names="Cambria">
     <table style="width: 100%">
             <tr>
                  <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 79px;">
                    <asp:Label runat="server" Text="Payee"></asp:Label><span style="color: red">*</span>
               </td>

                   <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 100px;">
                    <asp:TextBox runat="server" ID="payeeText" Width="138px"></asp:TextBox>
               </td>
                 <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 47px;">
                     <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" />
                  </td>
                 
                  <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                     Use holder's name</td>

                 </tr>

          <tr>
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 79px;">
                    <asp:Label runat="server" Text="Bank"></asp:Label><span style="color: red">*</span>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 100px;">

                   <asp:DropDownList runat="server" ID="bankText" Width="153px" AutoPostBack="True">
                </asp:DropDownList>

               </td>

               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 47px;">
                <asp:Label runat="server" Text="Branch"></asp:Label><span style="color: red">*</span>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">

                   
                       <asp:DropDownList runat="server" ID="branchText" Width="153px">
                                       </asp:DropDownList>

               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 45px;">
                   <asp:Label runat="server" Text="Account"></asp:Label><span style="color: red">*</span>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server"  ID="accountText"></asp:TextBox>
               </td>
           </tr>
        </table>
        
        
        
                   <asp:Panel ID="Panel16" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="10pt" GroupingText="Mobile Money Details" Width="785px">
                       <table style="width: 780px; height:30px;">
                           <tr>
                               <td colspan="1" style="height: 46px; width: 94px">
                                   <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile Money" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 46px; width: 249px">
                                   <dx:ASPxComboBox ID="cmbmobilemoney" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                   </dx:ASPxComboBox>
                               </td>
                               <td colspan="2" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                           </tr>
                           <tr>
                               <td colspan="1" style="height: 46px; width: 94px">
                                   <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile Number" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 46px; width: 249px">
                                   <dx:ASPxTextBox ID="txtmobilemonephone" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                    
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
                               <td colspan="1" style="width: 94px"></td>
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


    <asp:panel id="Panel9" runat="server" groupingtext="Attributes" font-names="Cambria" Width="785px">
        <table style="width: 785px">
         <tr>
            <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 94px;">
                       <asp:Label runat="server" Text="Trading Status"></asp:Label><span style="color: red">*</span>
                </td>
       <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 374px;">

                 
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                <asp:ListItem Text="Dealing Allowed" Value="Dealing Allowed"></asp:ListItem>
                <asp:ListItem Text="Trade Suspended" Value="Trade Suspended"></asp:ListItem>
            </asp:RadioButtonList> 

                </td>
            

         </tr>
            <tr>
                <td colspan ="1" style="width: 94px">
                    <asp:Label runat="server" Text="Client Type"></asp:Label><span style="color: red">*</span>
                </td>
                <td colspan ="1" style="width: 374px">
                    <asp:DropDownList runat="server" ID="clientTypes" AutoPostBack="True" Width="153px"></asp:DropDownList>
                </td>
                
<%--                runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">--%>
<%--                                   </dx:ASPxComboBox>--%>
                <td colspan ="1">
                    Tax</td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbTax" runat="server" AutoPostBack="True" Theme="BlackGlass" Width="250px">
                       
                    </dx:ASPxComboBox>
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
                                   <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Indigenous Zimbabwean?" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel11" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 9px; width: 249px">
<%--                                   <asp:RadioButtonList runat="server">--%>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                         RepeatDirection="Horizontal" RepeatLayout="Table">
                             <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                             <asp:ListItem Text="No" Value="No"></asp:ListItem>
                 </asp:RadioButtonList>  
<%--                                   </asp:RadioButtonList>--%>
                                   

<%--                                   <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">--%>
<%--                                   </dx:ASPxComboBox>--%>
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
                                   <dx:ASPxLabel ID="ASPxLabel13" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 20px; width: 249px">
                                   <dx:ASPxTextBox ID="raceText" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                                   <dx:ASPxLabel ID="ASPxLabel15" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 18px; width: 249px">
                                     <asp:RadioButtonList ID="dis" runat="server" 
                         RepeatDirection="Horizontal" RepeatLayout="Table">
                             <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                             <asp:ListItem Text="No" Value="No"></asp:ListItem>
                
                 </asp:RadioButtonList>  
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
                                        <dx:ASPxComboBox ID="cmbNationality" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                                        </dx:ASPxComboBox>

                                    </td>
                                 </tr>
                           <tr>
                               <td colspan="1" style="height: 4px; width: 429px">
                                   <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality By?" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel17" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 4px; width: 249px">
                                   <asp:RadioButtonList ID="natBy" runat="server" 
                         RepeatDirection="Horizontal" RepeatLayout="Table">
                             <asp:ListItem Text="Birth" Value="Birth"></asp:ListItem>
                             <asp:ListItem Text="Descendancy" Value="Descendancy"></asp:ListItem>
                   <asp:ListItem Text="Adoption" Value="Adoption"></asp:ListItem>
                 </asp:RadioButtonList> 
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


    <asp:panel runat="server" id="panelSave" font-names="Cambria" width="785px" groupingtext="Attachments">
         <table>
             <tr>
                    <td colspan ="8">
                        <dx:ASPxLabel ID="ASPxLabel52" runat="server" Text="____________________________________________________________________________________________________________________" Theme="BlackGlass">
                        </dx:ASPxLabel>
                    </td>

             </tr>
             <tr>                 
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
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

             </tr>
              <tr>                 
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td align="right" colspan ="1">
                     <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Document Name" Theme="Glass">
                     </dx:ASPxLabel>
                  </td>
                 <td colspan ="1">
                     <dx:ASPxComboBox ID="txtdocumentname" runat="server" AnimationType="Slide" AutoPostBack="True" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="BlackGlass" ValueType="System.String" Width="250px">
                     </dx:ASPxComboBox>
                  </td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>

             </tr>
              <tr>                 
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan align="right" ="1">
                     <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Document" Theme="Glass">
                     </dx:ASPxLabel>
                  </td>
                 <td colspan ="1">
                     <asp:FileUpload ID="FileUpload1" runat="server" />
                  </td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>

             </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td ="1"="" align="right" colspan="">&nbsp;</td>
                    <td colspan="1">
                        <dx:ASPxButton ID="ASPxButton10" runat="server" Text="Upload" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
             </tr>
                <tr>
                        <td colspan ="8" align ="center" style="height: 24px">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="BlackGlass" Width="470px">
                            </dx:ASPxGridView>
                        </td>

                </tr>
             <tr>
                    <td colspan ="8" align ="center">
                        &nbsp;</td>
             </tr>
             <tr>
                    <td colspan ="8" align ="center">  
                         <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel"
        Modal="True">
    </dx:ASPxLoadingPanel>
                    </td>

             </tr>

         </table>

     </asp:panel>


    <asp:panel id="panelsaving0" runat="server" groupingtext="Joint Account Holders" width="785px" visible="False">
            <table>
                <tr>
                    <td align="center" colspan="8" style="height: 17px; width: 812px;">
                        <asp:Panel ID="Panel14" runat="server" Font-Names="Cambria" GroupingText="Details" style="height: 176px">
                            <table width="810px">
                                <tr>
                                    <td align="center" colspan="9">
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJSurname0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="8">
                                        <dx:ASPxTextBox ID="txtJsurname0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJforenames0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="8">
                                        <dx:ASPxTextBox ID="txtJforenames0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJforenames1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="8">
                                        <dx:ASPxTextBox ID="txtJemail1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="LBLJIDTYPE0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" >
                                        <dx:ASPxComboBox ID="cmbJIDType0" runat="server" Theme="BlackGlass" Width="200px">
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJID0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="1">
                                        <dx:ASPxTextBox ID="TXTjiD3" runat="server" BackColor="#E4E4E4" Height="16px" Theme="BlackGlass" Width="244px">
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                </tr>
                                <tr>
<%--                                    <td align="left" colspan="1">--%>
<%--                                        <dx:ASPxLabel ID="lblJnationality0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">--%>
<%--                                        </dx:ASPxLabel>--%>
<%--                                    </td>--%>
<%--                                    <td align="left" colspan="2">--%>
<%--                                        <dx:ASPxComboBox ID="cmbJnationality0" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">--%>
<%--                                        </dx:ASPxComboBox>--%>
<%--                                    </td>--%>
                                    <td colspan="1"></td>
                                    <td colspan="1">&nbsp;</td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJdob0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Of Birth" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="2">
                                        <dx:ASPxDateEdit ID="txtJdob0" runat="server" AutoPostBack="True" DisplayFormatString="dd/MMMM/yyyy" EditFormat="Custom" EditFormatString="dd/MMMM/yyyy" Theme="BlackGlass" Width="250px">
                                        </dx:ASPxDateEdit>
                                    </td>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lbljGender0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="1">
                                        <asp:RadioButton ID="rdJmale0" runat="server" AutoPostBack="True" GroupName="Gender2" Text="Male" />
                                        <asp:RadioButton ID="rdJfemale0" runat="server" AutoPostBack="True" GroupName="Gender2" Text="Female" />
                                        <asp:RadioButton ID="rdJNa0" runat="server" AutoPostBack="True" GroupName="Gender2" Text="N/A" />
                                    </td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="8" style="width: 812px">
                        <br />
                        <dx:ASPxButton ID="btnJadd2" runat="server" Text="Add" Theme="BlackGlass">
                        </dx:ASPxButton>
                        <br />
                        <dx:ASPxGridView ID="grdJointAccounts" runat="server" Theme="Aqua" Width="600px">
                        </dx:ASPxGridView>
                        <br />
                        <dx:ASPxButton ID="btnJadd3" runat="server" Text="Done" Theme="BlackGlass">
                        </dx:ASPxButton>
                        <br />
                    </td>
                </tr>
            </table>
        </asp:panel>



    <asp:panel id="panel2" runat="server" width="745px" groupingtext="Company Representatives" visible="False">
            <table>
                <tr>
                    <td align="center" colspan="8" style="height: 17px; width: 812px;">
                        <asp:Panel ID="Panel5" runat="server" Font-Names="Cambria" GroupingText="Details">
                            <table width="810px">
                                <tr>
                                    <td align="center" colspan="9">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="8">
                                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="8">
                                        <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="8">
                                        <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left">
                                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Theme="BlackGlass" Width="200px">
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="1">
                                        <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" BackColor="#E4E4E4" Height="16px" Theme="BlackGlass" Width="244px">
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="2">
                                        <dx:ASPxComboBox ID="cmbJnationality0" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td colspan="1"></td>
                                    <td colspan="1">&nbsp;</td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Of Birth" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="2">
                                        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" AutoPostBack="True" DisplayFormatString="dd/MMMM/yyyy" EditFormat="Custom" EditFormatString="dd/MMMM/yyyy" Theme="BlackGlass" Width="250px">
                                        </dx:ASPxDateEdit>
                                    </td>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="1">
                                        <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" GroupName="Gender2" Text="Male" />
                                        <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="Gender2" Text="Female" />
                                        <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" GroupName="Gender2" Text="N/A" />
                                    </td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="8" style="width: 812px">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Add" Theme="BlackGlass">
                        </dx:ASPxButton>
                        <br />
                        <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Aqua" Width="600px">
                        </dx:ASPxGridView>
                        <br />
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Done" Theme="BlackGlass">
                        </dx:ASPxButton>
                        <br />
                    </td>
                </tr>
            </table>
        </asp:panel>

    <asp:panel runat="server" id="panel8" width="785px" font-names="Cambria" groupingtext="&nbsp;">
                 <div style="text-align: center">
                         <asp:Button runat="server" Text="Save" OnClick="Unnamed23_Click"></asp:Button>
                     </div>
         </asp:panel>
</asp:Content>


