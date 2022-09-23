<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AddClientBill.aspx.vb" Inherits="Reporting_AddClientBill"  %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="1000px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="1000px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Billing&gt;&gt;Add Accounts to Billing Groups" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="1000px">
            <tr>
                <td colspan ="1" align="right" style="width: 292px">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Name/Account No./Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtSeachName" runat="server" Theme="BlackGlass" Width="400px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    <dx:ASPxButton ID="btnSearch" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="80px" CausesValidation="false">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right" style="width: 292px">
                    &nbsp;</td>
                <td colspan ="1" width="301">
                    <dx:ASPxListBox ID="lstSearchAcc" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="400px">
                 <ValidationSettings>
                     <RequiredField IsRequired="true" />
                 </ValidationSettings>
                           </dx:ASPxListBox>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 292px"></td>
                <td colspan ="2">
                    <dx:ASPxLabel ID="lblCDsNumber" runat="server" Theme="BlackGlass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="lblCDsAccount" runat="server" Theme="BlackGlass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="lbltelephone" runat="server" Theme="BlackGlass">
                    </dx:ASPxLabel>
                </td>
                
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan="1" style="width: 292px">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bill Group" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="2">
                    <dx:ASPxComboBox ID="cmbbillgroup" runat="server" DropDownStyle="DropDown"  AutoPostBack="True" Width="400px" IncrementalFilteringMode="StartsWith" Theme="BlackGlass">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 292px">
                    &nbsp;</td>
                <td width="301" colspan="4">
                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Add Account" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                    
                    <dx:ASPxButton ID="btnPrint0" runat="server" Text="Clear" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 292px">&nbsp;</td>
                <td width="301">
                    &nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>

            <tr>
                <td colspan="5">
                    <hr />
                    <table class="auto-style1">
                        <tr>
                            <td style="width: 107px">
                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Group" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbbillgroupselect" runat="server" AutoPostBack="True" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Theme="BlackGlass" Width="200px">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Glass" Width="100%">
                        <SettingsPager Visible="True">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
            </tr>

            <tr>
                <td colspan="1" style="width: 292px"></td>
                <td colspan="1">&nbsp;</td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>

