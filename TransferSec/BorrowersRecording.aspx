<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BorrowersRecording.aspx.vb" Inherits="Enquiries_BorrowersRecording" title="Borrowers Record" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Lending and Borrowing&gt;&gt;Borrowers" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel8" runat="server" GroupingText="Search" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass">
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
                    <td colspan ="1">
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
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxListBox ID="lstNameSearch" runat="server" ValueType="System.String" AutoPostBack="True" Theme="Glass" Width="710px"></dx:ASPxListBox>

                </td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblClientID" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtForenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7" align="center" >
                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>

            </tr>
         
        </table>

    </asp:panel>
        <%--<asp:panel id="Panel11" runat="server" GroupingText="Lending Details" Font-Names="Cambria">
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
                    <td colspan ="1">
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
                    <dx:ASPxDateEdit ID="txtExpiryDate" runat="server" Theme="BlackGlass" Width="250px">
                    </dx:ASPxDateEdit>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="8" align ="center">
                        &nbsp;</td>

            </tr>
               
        </table>

    </asp:panel>--%>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

