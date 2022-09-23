<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="NewAccountCreation.aspx.vb" Inherits="TSecMode_NewAccountCreation" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxEditors" Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxLoadingPanel" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:panel id="Panel4" runat="server" groupingtext="Account Type" font-names="Cambria">
       <asp:RadioButtonList ID="accType" runat="server" AutoPostBack="True"
                         RepeatDirection="Horizontal" RepeatLayout="Table">
                             <asp:ListItem Text="Individual" Value="I"></asp:ListItem>
                             <asp:ListItem Text="Joint" Value="J"></asp:ListItem>
                   <asp:ListItem Text="Corporate" Value="C"></asp:ListItem>
                 </asp:RadioButtonList>
  </asp:panel>
    
  <asp:Panel ID="Panel8" runat="server" Font-Names="Cambria" groupingtext="Company Details" Visible="False">
            <table style="width: 1004px">
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
        </asp:Panel>
    
    

    <asp:panel id="Panel10" runat="server" groupingtext="Details" font-names="Cambria">
        <table style="width: 100%">
          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">
                <asp:Label runat="server" Text="Id Number" ID="accNameType"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:TextBox runat="server" ID="idNumberTxt"></asp:TextBox>
                      <asp:TextBox runat="server" ID="jointName"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Surname" ID="indSurname"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server" ID="surnameTxt"></asp:TextBox>
               </td>
              
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Forename" ID="indForeName"></asp:Label>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server" ID="forenameTxt"></asp:TextBox>
               </td>
           </tr>
        
        </table>
    </asp:panel>
    
    
    <asp:panel id="Panel5" runat="server" groupingtext="Shares" font-names="Cambria">
        <table style="width: 100%">
          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 155px;">
                <asp:Label runat="server" Text="Do you have shares?" ID="Label1"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:RadioButtonList ID="accType0" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Table">
                       <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                       <asp:ListItem Text="No" Value="N"></asp:ListItem>
                   </asp:RadioButtonList>
               </td>
              
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   &nbsp;</td>
              
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   &nbsp;</td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   &nbsp;</td>
           </tr>
        
        </table>
    </asp:panel>

    <asp:panel id="Panel1" runat="server" groupingtext="Certificate Details" font-names="Cambria">
        <table style="width: 100%">
          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">
                <asp:Label runat="server" Text="Certificate Number"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:TextBox runat="server" ID="certNumberTxt"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Holder"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server" ID="holderTxt"></asp:TextBox>
               </td>
              
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Company"></asp:Label>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server" ID="certCompany"></asp:TextBox>
               </td>
           </tr>
            
       
<%--             <tr>--%>
<%--                <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">--%>
<%--                    Company</td>--%>
<%--                    <td class="dxcpCurrentColor_Glass" style="height: 28px">--%>
<%--                        <asp:TextBox ID="certCompany" runat="server"></asp:TextBox>--%>
<%--                    </td>--%>
<%--                 </tr>--%>
             <tr>
                 <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;"></td>
                 <td class="dxcpCurrentColor_Glass" style="height: 28px">
                     <asp:Button runat="server" OnClick="Unnamed13_Click" Text="Save" />
                 </td>
            </tr>
             <tr>
                <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">
                 </td>
                    <td class="dxcpCurrentColor_Glass" style="height: 28px">
                            <asp:GridView runat="server" ID="grdApps" ShowFooter="true" Width="100%"></asp:GridView>
                    </td>
                 </tr>
        </table>
    </asp:panel>

    

    <asp:panel id="Panel3" runat="server" groupingtext="" font-names="Cambria">
        <table style="width: 100%">
          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 100%; text-align: center;">
                    <asp:Button runat="server" Text="Save" OnClick="Unnamed12_Click"></asp:Button>
               </td>
           </tr>
        </table>
    </asp:panel>
</asp:Content>
