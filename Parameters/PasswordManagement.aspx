<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="PasswordManagement.aspx.vb" Inherits="Parameters_PasswordManagement" title="System Password Defination" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="System Access&gt;&gt;Password Management" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Password Defination" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    &nbsp;</td>

            </tr>
             <tr>
                <td colspan ="1" align="right" style="width: 415px; height: 23px;">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Minimum Password Length(enter numeric)" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301" style="height: 23px">
                    <dx:ASPxTextBox ID="txtminlength" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                 </td>
                <td colspan ="1" style="height: 23px">
                    </td>
                <td colspan ="1" style="height: 23px"></td>
                <td colspan ="1" style="height: 23px"></td>

            </tr>
            <tr>
                <td align="right" colspan="1" style="width: 415px; height: 23px;">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maximum Password Length(enter numeric)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 23px" width="301">
                    <dx:ASPxTextBox ID="txtmaxlength" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan ="1" align="right" style="width: 415px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Password Type" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxComboBox ID="cmbPasswordType" runat="server" EnableTheming="True" Theme="BlackGlass" Width="250px">
                        <Items>
                            <dx:ListEditItem Text="Alphanumeric" Value="Alphanumeric" />
                            <dx:ListEditItem Text="Alphabet Only" Value="Alphabet Only" />
                            <dx:ListEditItem Text="Numeric Only" Value="Numeric Only" />
                            <dx:ListEditItem Text="Alphanumeric + Special Character" Value="Alphanumeric & Special Character" />
                        </Items>
                    </dx:ASPxComboBox>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                <tr>
                <td colspan ="1" align="right" style="width: 415px">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Validity Period(in days)" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtvalidity" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                <tr>
                <td colspan ="1" align="right" style="width: 415px">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lock out attempts(enter numeric)" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtattempts" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                <tr>
                <td colspan ="1" align="right" style="width: 415px">
                    &nbsp;</td>
                <td colspan ="1" width="301">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 415px">&nbsp;</td>
                <td width="301">
                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Update" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 415px"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
  
        <!--Settlement-->
       
</asp:Panel>
  
</div>
</asp:Content>

