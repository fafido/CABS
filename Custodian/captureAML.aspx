<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CaptureAML.aspx.vb" Inherits="CaptureAML" title="Capture AML" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Utities&gt;&gt;Capture AML List" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="AML List">

                <table width="810px">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Identification No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td>
        <dx:ASPxTextBox ID="txtIdNo" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="287px">
        </dx:ASPxTextBox>
        </td>

</tr>
                    
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td>
                            <dx:ASPxTextBox ID="txtSurnames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td>
                            <dx:ASPxTextBox ID="txtForenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtmobile" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="287px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbtype" runat="server" EnableCallbackMode="True"  Theme="Glass" Width="250px">
                                <Items>
                                    <dx:ListEditItem Text="AML" Value="AML" />
                                    <dx:ListEditItem Text="PEP" Value="PEP" />
                                </Items>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td>
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Save" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
        </table>
        </asp:Panel>

         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="AML List" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td align="center" colspan="8">
        <dx:ASPxGridView ID="grdPortfolios" runat="server" Theme="Aqua" Width="650px">
        </dx:ASPxGridView>
        <br />
        <br />
        <br />
        <br />
    </td>
   

</tr>
                 
                    <tr>
                        <td align="center" colspan="8">
                            &nbsp;</td>
                    </tr>
                 
        </table>
        </asp:Panel>
        
</asp:Panel>
  
</div>
</asp:Content>

