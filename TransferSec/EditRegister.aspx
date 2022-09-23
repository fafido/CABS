<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="EditRegister.aspx.vb" Inherits="TransferSec_EditRegister" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:panel id="Panel1" runat="server" width="840px" font-names="Arial" font-size="Medium" backcolor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Enquiries&gt;&gt;Add Certificates" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="4">
                    <dx:ASPxListBox ID="lstNames" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="485px">
                    </dx:ASPxListBox>
                    </td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Holder Basic Details">

                <table width="810px">

              

                    <tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Full name" Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4" ReadOnly="true">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Number" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td>
        <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Theme="BlackGlass" Width="287px" BackColor="#E4E4E4" Height="19px">
        </dx:ASPxTextBox>
        </td>

</tr>
<%--<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Holder No" Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtHolder" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Certificate Number" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td>
        <dx:ASPxTextBox ID="txtCertNumber" runat="server" Theme="BlackGlass" Width="287px" BackColor="#E4E4E4" Height="19px">
        </dx:ASPxTextBox>
        </td>

</tr>
                    
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="3">
                            <dx:ASPxComboBox ID="cmbSecurities" runat="server" Height="22px" ValueType="System.String" Visible="True" Width="250px">
        </dx:ASPxComboBox>
                            </td>

                    </tr>--%>
                    <tr>
                            <td colspan ="1">
                                &nbsp;</td>
                        <td colspan ="3">
                            &nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            &nbsp;</td>
                        <td colspan="3">
                            <dx:ASPxButton ID="btnView0" runat="server" Text="Add" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
        </table>
        </asp:Panel>
        
</asp:panel>

    </div>


</asp:Content>
