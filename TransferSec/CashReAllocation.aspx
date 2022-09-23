<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CashReAllocation.aspx.vb" Inherits="CashReAllocation" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Cash Maintenance&gt;&gt;Cash Re-Allocation" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Cash Re-Allocation" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1" align="left">
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
                <td colspan ="1" align="right">
                    &nbsp;</td>
                <td colspan ="1" width="301">
                    <dx:ASPxListBox ID="lstSearchAcc" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="400px">
                 <ValidationSettings>
                     <RequiredField IsRequired="True" />
                 </ValidationSettings>
                           </dx:ASPxListBox>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1"></td>
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
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager/ Bank Account" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="2">
                    <dx:ASPxComboBox ID="cmbassetmanager" runat="server" DropDownStyle="DropDown" DropDownWidth="550" IncrementalFilteringMode="StartsWith" Theme="BlackGlass">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxDateEdit ID="txtDateFrom" EditFormatString="dd-MMM-yyyy" runat="server" Theme="BlackGlass">
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
                    <dx:ASPxDateEdit ID="txtDateTo" EditFormatString="dd-MMM-yyyy" runat="server" Theme="BlackGlass">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan="1">&nbsp;</td>
                <td width="301">
                    <dx:ASPxButton ID="btnPrint1" CausesValidation="false"  runat="server" Text="Show Entries" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" valign="top">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Re-Allocation Entry" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxListBox ID="lstentry" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="400px">
                  <ValidationSettings RequiredField-IsRequired="true" ></ValidationSettings>
                          </dx:ASPxListBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" valign="top">
                    <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Value Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxDateEdit ID="txtvaluedate" runat="server" EditFormatString="dd-MMM-yyyy" Theme="BlackGlass">
                        <ValidationSettings RequiredField-IsRequired="true" ></ValidationSettings>
                    </dx:ASPxDateEdit>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" valign="top">&nbsp;</td>
                <td width="301">
                    <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="Small" Text="Re-Allocate to" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" valign="top">
                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Name/Account No./Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxTextBox ID="txtSeachName0" runat="server" Theme="BlackGlass" Width="400px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">
                    <dx:ASPxButton ID="btnSearch0" runat="server" CausesValidation="false" Text="&gt;&gt;" Theme="BlackGlass" Width="80px">
                    </dx:ASPxButton>
                </td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" valign="top">&nbsp;</td>
                <td width="301">
                    <dx:ASPxListBox ID="lstreceiver" runat="server" Theme="Glass" ValueType="System.String" Width="400px">
                   <ValidationSettings RequiredField-IsRequired="true" ></ValidationSettings>
                         </dx:ASPxListBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1"></td>
                <td colspan ="1">
                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Re-Allocate" Theme="BlackGlass" Width="150px">
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

