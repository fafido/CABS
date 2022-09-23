<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Equity_Reporting.aspx.vb" Inherits="Equity_Reporting" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" 
                           Text="Reporting&gt;&gt;Trade Status Report" Font-Names="Cambria" 
                           Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxDateEdit ID="txtDateFrom" EditFormatString="dd-MMM-yyyy" runat="server" Theme="BlackGlass" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan="1"></td>
                <td colspan="1"></td>
                <td colspan="1"></td>
            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxDateEdit ID="txtDateTo" EditFormatString="dd-MMM-yyyy" runat="server" Theme="BlackGlass" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" 
                        Font-Size="Small" Text="Status" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxComboBox ID="cmbIssuer" runat="server" Height="23px" Width="250px">
                    </dx:ASPxComboBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" 
                        Font-Size="Small" Text="Company" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxComboBox ID="cmbcompany" runat="server" Height="23px" Width="250px">
                    </dx:ASPxComboBox>
                </td>
                <td colspan="1">
                    &nbsp;</td>
                <td colspan="1">
                    &nbsp;</td>
                <td colspan="1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="3" width="301">
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td>
                                <dx:ASPxTextBox ID="txtAccountNo" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton4" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">&nbsp;</td>
                <td colspan="3" width="301">
                    <dx:ASPxListBox ID="lstSearchAcc" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="400px">
                    </dx:ASPxListBox>
                </td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1"></td>
                <td colspan ="1">
                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                    &nbsp;<dx:ASPxButton ID="btnPrint0" runat="server" Text="Clear" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                </td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>

